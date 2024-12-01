using System.Threading.Channels;
namespace ChannelsImplementation
{
    public class LogService
    {
        private readonly Channel<string> _logChannel;
        public LogService()
        {
            // ایجاد یک کانال بدون محدودیت ظرفیت
            _logChannel = Channel.CreateUnbounded<string>();
        }

        public async Task LogAsync(string message)
        {
            await _logChannel.Writer.WriteAsync(message);
        }

        public async Task StartProcessingAsync()
        {
            await foreach (var log in _logChannel.Reader.ReadAllAsync())
            {
                Console.WriteLine($"Log: {log}");
                await Task.Delay(500);
            }
        }

        public void Complete()
        {
            _logChannel.Writer.Complete();
        }
    }

}
