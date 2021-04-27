namespace senai.inlock.webApi.Controllers
{
    internal class SymmetricSecurityKey
    {
        private byte[] vs;

        public SymmetricSecurityKey(byte[] vs)
        {
            this.vs = vs;
        }
    }
}