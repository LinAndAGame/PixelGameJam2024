using System.Collections.Generic;

namespace GameData {
    public class Save_GlobalData {
        private static string SaveKey => nameof(Save_GlobalData);
        
        private static Save_GlobalData _I;

        public static Save_GlobalData I {
            get {
                if (_I == null) {
                    if (ES3.KeyExists(SaveKey) == false) {
                        _I = new Save_GlobalData();
                        ES3.Save(SaveKey, _I);
                    }
                    else {
                        _I = ES3.Load<Save_GlobalData>(SaveKey);
                    }
                }

                return _I;
            }
        }
        
        public int RemainingDays = 3;
        public int NeedGold      = 100;
        public int CurGold       = 0;

        public List<RoomData> AllCurRoomDatas = new List<RoomData>();

        public Save_KeyCodeConfig KeyCodeConfig = new Save_KeyCodeConfig();

        public Save_GlobalData() { }

        public void AddRoomData(RoomData roomData) {
            roomData.HasPlayed =  true;
            CurGold            += roomData.CurGold - roomData.BeDestroyedTimes * 1 - roomData.BeKilledTimes * 5;
        }
    }
}