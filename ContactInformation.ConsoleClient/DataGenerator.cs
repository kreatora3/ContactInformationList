namespace ContactInformation.ConsoleClient
{
    using ContactInformation.Data;

    public abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ContactDbContext db;
        private int count;

        public DataGenerator(IRandomDataGenerator random, ContactDbContext contacts, int numberToGenerate)
        {
            this.random = random;
            this.db = contacts;
            this.count = numberToGenerate;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected ContactDbContext Database
        {
            get
            {
                return this.db;
            }
        }

        protected int Count
        {
            get
            {
                return this.count;
            }
        }

        public abstract void Generate();
    }
}
