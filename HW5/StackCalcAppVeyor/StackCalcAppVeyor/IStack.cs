namespace StackCalcAppVeyor
{
    /// <summary>
    /// Interface describing basic stack commands
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Push in stack
        /// </summary>
        public void Push(float element);

        /// <summary>
        /// Pop from stack
        /// </summary>
        public float Pop();

        /// <summary>
        /// Check stack
        /// </summary>
        public bool IsEmpty();
    }
}