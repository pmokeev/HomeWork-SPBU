namespace StackCalcAppVeyor
{
    /// <summary>
    /// Interface describing basic stack commands
    /// </summary>
    public interface IStack
    {
        void Push(float element);

        float Pop();

        bool IsEmpty();
    }
}
