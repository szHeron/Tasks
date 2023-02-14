using System.ComponentModel;

namespace Tasks.Enums
{
    public enum TaskState
    {
        [Description("A fazer")]
        NotStarted = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluido")]
        Finished = 3
    }
}
