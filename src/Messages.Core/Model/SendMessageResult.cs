namespace Messages.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SendMessageResult
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
