namespace Logic
{
    public static class NumberCreator
    {
        private static int _id;

        public static int CreateNumber()
        {
            return ++_id;
        }
    }
}