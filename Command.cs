using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using LabApi.Features.Wrappers;
using MapGeneration;
using static Unity.Collections.AllocatorManager;

namespace ControllClassDRoom
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Command : ICommand

    {
        public string[] Aliases => Array.Empty<string>();

        public string Description => "Controlling system in Class-D Block <color=yellow> {help} {status} ";

        string ICommand.Command => "dblock";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (arguments.At(0) == "help")
            {
                response = "\nCOMMANDS: <color=red>LOCK <color=red>CLOSE <color=green>UNLOCK <color=green>OPEN";

                return true;
            }
            if (arguments.At(0) == "status")
            {
                response = null;

                foreach (Room room in Room.Get(RoomName.LczClassDSpawn))
                {
                    if (room.Name == RoomName.LczClassDSpawn)
                    {
                        foreach (var Cdoor in room.Doors.Take(14))
                        {
                            if (Cdoor.IsLocked == true)
                            {

                                response = "<color=red>CLOSED";

                                return true;

                            }
                            if (Cdoor.IsLocked == false)
                            {

                                response = "<color=green>UNCLOSED";

                                return true;

                            }
                        }

                        return true;
                    }

                }


                return true;
            }

            if (arguments.Count == 0)
            {

                response = "Set values for controlling a Class-d Block";

                return false;

            }
            if (arguments.Count > 2)
            {

                response = "Please set a number";

                return false;

            }
            if (arguments.Count > 3)
            {

                response = "Arguments can'not be three more";

                return false;

            }
            if (arguments.At(0) == "unlock")
            {

                foreach (Room room in Room.Get(RoomName.LczClassDSpawn))
                {
                    response = "<color=green>All Class D Doors unlocked";
                    if (room.Name == RoomName.LczClassDSpawn)
                    {
                        foreach (var Cdoor in room.Doors.Take(14))
                        {
                            Cdoor.Lock(Interactables.Interobjects.DoorUtils.DoorLockReason.Isolation, false);
                        }

                        return true;
                    }

                }

            }
            if (arguments.At(0) == "lock")
            {

                foreach (Room room in Room.Get(RoomName.LczClassDSpawn))
                {
                    response = "<color=red>All Class D Doors locked";
                    if (room.Name == RoomName.LczClassDSpawn)
                    {
                        foreach (var Cdoor in room.Doors.Take(14))
                        {
                            Cdoor.Lock(Interactables.Interobjects.DoorUtils.DoorLockReason.Isolation, true);

                            Cdoor.IsOpened = false;
                        }
                        return true;
                    }
                }
            }
            if (arguments.At(0) == "close")
            {

                foreach (Room room in Room.Get(RoomName.LczClassDSpawn))
                {
                    response = "<color=red>All Class D Doors closed";
                    if (room.Name == RoomName.LczClassDSpawn)
                    {
                        foreach (var Cdoor in room.Doors.Take(14))
                        {
                            Cdoor.IsOpened = false;
                        }
                        return true;
                    }
                }

            }
            if (arguments.At(0) == "open")
            {

                foreach (Room room in Room.Get(RoomName.LczClassDSpawn))
                {
                    response = "<color=green>All Class D Doors opened";
                    if (room.Name == RoomName.LczClassDSpawn)
                    {
                        foreach (var Cdoor in room.Doors.Take(14))
                        {
                            Cdoor.IsOpened = true;
                        }
                        return true;
                    }
                }

            }

            //------------------------------------

            response = "Set values for controlling a Class - D Block";

            return false;
        }
    }
}

