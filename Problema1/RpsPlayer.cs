using Problema1.Enumerators;
using Problema1.Exceptions;

namespace Problema1
{
    public class RpsPlayer
    {
        public string PlayerName { get; private set; }
        public RpsChoicesEnum Choice { get; private set; }
        public RpsPlayer(string playerName, RpsChoicesEnum choice)
        {
            PlayerName = playerName;
            Choice = choice;
        }
        public RpsPlayer(string playerName, string choice)
        {
            PlayerName = playerName;
            RpsChoicesEnum enumChoice;
            if (RpsChoicesEnum.TryParse(choice, true, out enumChoice))
                Choice = enumChoice;
            else
                throw new NoSuchStrategyException("Please choose a valid game move (R, P or S).");
        }
    }
}
