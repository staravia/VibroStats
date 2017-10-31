using Google.Apis.Services;

namespace vibromark
{
    internal class DriveService
    {
        private BaseClientService.Initializer initializer;

        public DriveService(BaseClientService.Initializer initializer)
        {
            this.initializer = initializer;
        }
    }
}