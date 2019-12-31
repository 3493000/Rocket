using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public class PlayerInfoMgr : DataClassHandler<PlayerInfo>
    {
        public static DataDirtyRecorder dataDirtyRecorder = new DataDirtyRecorder();
        public PlayerInfoMgr()
        {
            Load();
            EnableAutoSave();
        }
    }
}