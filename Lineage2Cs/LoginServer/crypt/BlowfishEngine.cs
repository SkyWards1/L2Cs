using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.crypt
{
    public class BlowfishEngine
    {

        private bool encrypting = false;
        private byte[] workingKey = null;

        public void init(bool pEncrypting, byte[] key)
        {
            encrypting = pEncrypting;
            workingKey = key;
            setKey(workingKey);
        }

        private void setKey(byte[] key)
        {

        }

    }
}
