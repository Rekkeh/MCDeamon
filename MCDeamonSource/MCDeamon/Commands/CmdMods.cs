using System;

namespace MCDeamon
{
    public class CmdMods : Command
    {
        public override string name { get { return "Mods"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdMods() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            string Modlist = "";
            string temp;
            foreach (string Mod in Server.mods)
            {
                temp = Mod.Substring(0, 1);
                temp = temp.ToUpper() + Mod.Remove(0, 1);
                Modlist += temp + ", ";
            }
            Modlist = Modlist.Remove(Modlist.Length - 2);
            Player.SendMessage(p, "&9MCDeamon Moderation Team: " + Server.DefaultColor + Modlist);
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/Mods - Displays the list of MCDeamon Moderators.");
        }
    }
}