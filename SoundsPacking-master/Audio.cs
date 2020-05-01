using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject_SoundsPacking_
{
    class Audio
    {
        string _name; //filename.mp3
        long _secDuration; // file duration by seconds

        public string name //setter and getter for filename
        {
            get { return _name; }
            set { _name = value; }
        }

        public long secDuration //setter and getter for duration
        {
            get { return _secDuration; }
            set { _secDuration = value; }
        }
    }
}
