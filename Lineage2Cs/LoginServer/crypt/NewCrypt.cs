using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.crypt
{
    public class NewCrypt
    {
        private readonly BlowfishEngine _crypt;
	    private readonly BlowfishEngine _decrypt;

        public NewCrypt(byte[] blowfishKey)
        {
            _crypt = new BlowfishEngine();
            _crypt.init(true, blowfishKey);
            _decrypt = new BlowfishEngine();
            _decrypt.init(false, blowfishKey);
        }
    }
}
