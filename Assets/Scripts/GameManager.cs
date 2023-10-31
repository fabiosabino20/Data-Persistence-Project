using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class HallOfFame
    {
        public string nickname1;
        public string nickname2;
        public string nickname3;
        public string nickname4;
        public string nickname5;
        public int bestScore1;
        public int bestScore2;
        public int bestScore3;
        public int bestScore4;
        public int bestScore5;
    }

    [System.Serializable]
    public class CurrentUserData
    {
        public string nickname;
        public int bestScore;
    }

    public void SaveCurrentUserData(string nicknameRcv, int bestScoreRcv)
    {
        CurrentUserData data = new()
        {
            nickname = nicknameRcv,
            bestScore = bestScoreRcv
        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/currentuserdata.json", json);
    }

    public CurrentUserData LoadCurrentUserData()
    {
        string path = Application.persistentDataPath + "/currentuserdata.json";
        CurrentUserData data;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<CurrentUserData>(json);
        }
        else
        {
            data = null;
        }

        return data;
    }

    public void SaveHallOfFameData()
    {
        HallOfFame data = LoadHallOfFameData();
        CurrentUserData currentUserData = LoadCurrentUserData();

        if (data != null)
        {
            string nicknameAux = currentUserData.nickname, nicknameAux1;
            int bestScoreAux = currentUserData.bestScore, bestScoreAux1;

            if (bestScoreAux > data.bestScore1)
            {
                nicknameAux1 = data.nickname1;
                bestScoreAux1 = data.bestScore1;
                data.nickname1 = nicknameAux;
                data.bestScore1 = bestScoreAux;
                nicknameAux = nicknameAux1;
                bestScoreAux = bestScoreAux1;
            }
            if (bestScoreAux > data.bestScore2)
            {
                nicknameAux1 = data.nickname2;
                bestScoreAux1 = data.bestScore2;
                data.nickname2 = nicknameAux;
                data.bestScore2 = bestScoreAux;
                nicknameAux = nicknameAux1;
                bestScoreAux = bestScoreAux1;
            }
            if (bestScoreAux > data.bestScore3)
            {
                nicknameAux1 = data.nickname3;
                bestScoreAux1 = data.bestScore3;
                data.nickname3 = nicknameAux;
                data.bestScore3 = bestScoreAux;
                nicknameAux = nicknameAux1;
                bestScoreAux = bestScoreAux1;
            }
            if (bestScoreAux > data.bestScore4)
            {
                nicknameAux1 = data.nickname4;
                bestScoreAux1 = data.bestScore4;
                data.nickname4 = nicknameAux;
                data.bestScore4 = bestScoreAux;
                nicknameAux = nicknameAux1;
                bestScoreAux = bestScoreAux1;
            }
            if (bestScoreAux > data.bestScore5)
            {
                data.nickname5 = nicknameAux;
                data.bestScore5 = bestScoreAux;
            }
        }
        else
        {
            data.nickname1 = currentUserData.nickname;
            data.bestScore1 = currentUserData.bestScore;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/halloffame.json", json);
    }

    public HallOfFame LoadHallOfFameData()
    {
        string path = Application.persistentDataPath + "/halloffame.json";
        HallOfFame data;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<HallOfFame>(json);
        }
        else
        {
            data = new()
            {
                nickname1 = null,
                bestScore1 = 0
            };
        }

        return data;
    }
}
