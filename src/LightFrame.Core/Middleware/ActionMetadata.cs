namespace LightFrame.Core.Middleware
{
    public class ActionMetadata
    {
        public string Description { get; private set; }
        public MessageType Type { get; private set; }

        public enum MessageType
        {
            Unknown,
            Web,
            Bus
        }

        public ActionMetadata(string name, MessageType type = MessageType.Unknown)
        {
            Description = name;
            Type = type;
        }
    }
}
