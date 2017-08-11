using System.Threading.Tasks;

namespace LightFrame.Core
{
    public static class TaskExt
    {
        public static Task Complete => Task.FromResult(0);
    }
}
