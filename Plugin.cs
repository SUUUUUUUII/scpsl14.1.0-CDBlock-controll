using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Interactables.Interobjects;
using LabApi.Events;
using LabApi.Features;
using LabApi.Features.Wrappers;
using LabApi.Loader.Features.Plugins;
using MapGeneration;

namespace ControllClassDRoom
{
    public class Plugin : LabApi.Loader.Features.Plugins.Plugin
    {

        

        System.Random random = new System.Random();
        public override string Name => "ControllPlugin";

        public override string Description => "Controll or Lock ClassD Room or Doors";

        public override string Author => "IIIAuPMa";

        public override Version Version => new Version(1, 4, 1);

        public override Version RequiredApiVersion => new Version(1, 4);

        public override void Disable()
        {
            LabApi.Events.Handlers.ServerEvents.RoundStarted -= OnControll;
        }

        public override void Enable()
        {
            LabApi.Events.Handlers.ServerEvents.RoundStarted += OnControll;
        }
        public void OnControll()
        {

            List<Room> doors = new List<Room>();

            foreach (Door Doors in Door.Get(FacilityZone.LightContainment))

            foreach (Room room in Room.Get(RoomName.LczClassDSpawn)) 

            foreach (Room MainCDRoom in Room.Get(FacilityZone.LightContainment))

            foreach (Player player in Player.List)
                        {
                           
                        if (room.Name == RoomName.LczClassDSpawn)
                            {
                                foreach (var Cdoor in room.Doors.Take(14)) 
                                {
                                    Cdoor.Lock(Interactables.Interobjects.DoorUtils.DoorLockReason.Isolation, true);
                                }
                            }

                        }
            }

        }


    }