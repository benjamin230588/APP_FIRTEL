using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APP_FIRTEL.Clases
{
    public class ByteImage : Image
    {
        public Func<byte[]> GetBytes { get; set; }
    }
}
