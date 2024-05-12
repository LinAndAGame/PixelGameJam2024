using GameData;
using Room;
using UnityEngine;

namespace Apartment {
    public class ApartmentCtrl : MonoBehaviour {
        public void EnterRoom(BaseRoomCtrl roomCtrl) {
            
        }

        public void ExitRoom(RoomData roomData) {
            Save_GlobalData.I.AddRoomData(roomData);
        }
    }
}