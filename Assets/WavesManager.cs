using UnityEngine;
using System.Collections;

public class WavesManager : MonoBehaviour {
    public int wave;

    [Header("Plateia Shooter")]
    public float ShootTime;
    public float ShootTimeVar;
    [Header("Seguranca Spawner")]
    public float SegurancaTime;
    public float SegurancaTimeVar;
    public int NumSegurancaMax;
    public int NumSegurancaMin;

    [Space(5)]
    public SpawnObj PlateiaShooter, EnemySpawn1, EnemySpawn2;

    public float NextWaveTime;
	// Use this for initialization
	void Start () {
        InvokeRepeating("NextWave", 0, NextWaveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    public void NextWave()
    {
        wave++;

        ShootTime = ShootTime * 0.95f;
        ShootTimeVar = ShootTimeVar * 0.9f;

        SegurancaTime = SegurancaTime * 0.99f;
        SegurancaTimeVar = SegurancaTimeVar * 0.95f;
        NumSegurancaMin = 1 + (wave / 8);
        NumSegurancaMax = 1 + (wave / 3);

        PlateiaShooter.Time = ShootTime;
        PlateiaShooter.TimeVar = ShootTimeVar;

        EnemySpawn1.Time = EnemySpawn2.Time = SegurancaTime;
        EnemySpawn1.TimeVar = EnemySpawn2.TimeVar = SegurancaTimeVar;
        EnemySpawn1.Max = EnemySpawn2.Max = NumSegurancaMax;
        EnemySpawn1.Min = EnemySpawn2.Min = NumSegurancaMin;
    }
}
