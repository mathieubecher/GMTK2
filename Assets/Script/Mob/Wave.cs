using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public Spawner spawn;
    public int counter;
    public SpawnManager manager;
    
    // Evolution de la vague
    public int actualCounter = 0;
    public float timer; 
    public Wave(SpawnManager _manager, int _counter, Spawner _spawn)
    {
        manager = _manager;
        counter = _counter;
        spawn = _spawn;
        //Debug.Log("Début de vague sur le spawner "+_spawn.id+" de valeur "+counter);
        
        timer = Random.value / 2 + 0.5f;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(actualCounter >= counter && timer < 0) Next();
        else if (timer <= 0)
        {
            int maxCounter = counter - actualCounter;
            float maxrand = 0;
            // Mob appelable
            List<Mob> callable = new List<Mob>();
            foreach (Mob mob in manager.prefabs)
            {
                if (mob.counter <= maxCounter)
                {
                    maxrand += mob.proba;
                    callable.Add(mob);
                }
            }
            // Recherche d'un mob
            float rand = Random.value * maxrand;
            Debug.Log("new mob, actual counter :"+actualCounter + ", callables count : "+callable.Count+", max rand : "+maxrand +", rand : "+rand);
            
            Mob mobToSpawn = callable[0];
            int i = 0;
            while (rand > 0 && i < callable.Count)
            {
                mobToSpawn = callable[i];
                rand -= mobToSpawn.proba;
                Debug.Log(rand+ " " + mobToSpawn.name);
                if (rand > 0) ++i;
            }
            
            // Spawn du mob
            if (i < callable.Count)
            {
                actualCounter += mobToSpawn.counter;
                if (actualCounter == counter) timer = 10;
                else timer = mobToSpawn.interval/1000f;
                Mob instance = Object.Instantiate(mobToSpawn, spawn.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("GROSSE ERREUR");
            }

        }
        
    }

    public void Next()
    {
        manager.waves.Remove(this);
        if (manager.waves.Count >= 5 || Random.value >=0f)
        {
            CheckWave(Random.Range(0, manager.spawners.Count), counter + 2);
        }
        else
        {
            int leftIndice = ((spawn.id == 0) ? manager.spawners.Count - 1 : spawn.id - 1);
            CheckWave(leftIndice, (int)Mathf.Floor(counter/2f) + 1);
            int rightIndice = ((spawn.id == manager.spawners.Count - 1) ? 0 : spawn.id + 1);
            CheckWave(rightIndice, (int)Mathf.Floor(counter/2f) + 1);
        }
        
        
    }

    public bool CheckWave(int indice, int newCounter)
    {
        if (manager.waves.Exists(x => x.spawn.id == indice))
        {
            manager.waves.Find(x => x.spawn.id == indice).counter += newCounter;
            return true;
        }
        else
        {
            Wave next = new Wave(manager, newCounter, manager.spawners.Find(x=>x.id == indice));
            manager.waves.Add(next);
            return false;
        }
    }
}
