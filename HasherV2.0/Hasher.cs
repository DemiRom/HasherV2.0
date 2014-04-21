using System;

namespace HasherV2._0
{
    class Hasher
    {
        long _h;

        private const String Letters = "acdegilmnoprstuw";

        Dialog _dialog = new Dialog();

        public long Hash(String s)
        {
            _h = 7;
            foreach (var t in s)
            {
                _h = _h * 37 + Letters.IndexOf(t);
            }
            return _h;
        }
    }
}
