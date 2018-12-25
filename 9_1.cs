namespace Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] bankAccount =
            {
new BankAccount(300, TypeAccount.savings),
new BankAccount(100, TypeAccount.current),
new BankAccount(900, TypeAccount.savings),
new BankAccount(500, TypeAccount.current),
new BankAccount(700, TypeAccount.savings),
};
            bankAccount[3].GetMoney(300);
            bankAccount[3].DepositMoney(200);
            bankAccount[3].TransferMoney(bankAccount[1], 100);
            bankAccount[3].GetInfo();
            bankAccount[3].Dispose();
        }
    }

    class BankAccount
    {
        private int numberAccount;
        private int balance;
        private TypeAccount type;
        private static int numberRnd = 0;
        private Queue<BankTransaction> history = new Queue<BankTransaction>();

        public int NumberRnd()
        {
            Random rand = new Random();
            numberRnd += rand.Next(100);
            return numberRnd;
        }

        public BankAccount(int balance, TypeAccount type)
        {
            this.numberAccount = NumberRnd();
            this.balance = balance;
            this.type = type;
        }


        public BankAccount(int balance)
        {
            this.numberAccount = NumberRnd();
            this.balance = balance;
        }

        public BankAccount(TypeAccount type)
        {
            this.numberAccount = NumberRnd();
            this.type = type;
        }

        public void Dispose()
        {
            FileStream fileHistory =
            new FileStream(@"Email.txt", FileMode.Open, FileAccess.Write, FileShare.Write);

            StreamWriter writer = new StreamWriter(fileHistory);
            foreach (BankTransaction q in history)
            {
                writer.WriteLine(q.ToString());
            }
            writer.Close();
            GC.SuppressFinalize(true);
        }
        public void GetInfo()
        {
            Console.WriteLine("Номер: " + numberAccount + "\nБаланс: " +
            balance + "\nТип: " + type + "\nИстория: \n");
            foreach (BankTransaction q in history)
            {
                Console.WriteLine(q.ToString());
            }
        }
        public void GetMoney(int balance)
        {	

            if (balance <= this.balance)
            {
                this.balance = this.balance - balance;
                Console.WriteLine("Операция выполнена успешно!\n" + "Остаток: " + this.balance);
            	history.Enqueue(new BankTransaction(this.balance));
            }
            else
            {
                Console.WriteLine("Недостаточно средств на выполнение этой операции!!!");
            }

        }

        public void DepositMoney(int balance)
        {
            //BankTransaction bankTransaction=new BankTransaction(balance);
            history.Enqueue(new BankTransaction(balance));
            this.balance += balance;
            Console.WriteLine("Операция выполнена успешно!\n" + "Баланс: " + this.balance);
        }

        public void TransferMoney(BankAccount bankAccount, int balance)
        {
            if (balance <= this.balance)
            {
                BankTransaction bankTransaction = new BankTransaction(balance);
                history.Enqueue(bankTransaction);
                this.balance -= balance;
                bankAccount.balance += balance;
                Console.WriteLine("Операция выполнена: \n" + "Баланс: " + this.balance);
            }
            else
            {
                Console.WriteLine("Недостаточно средств на выполнение этой операции!!!");
            }
        }
    }

    class BankTransaction
    {
        private readonly int balance;
        private readonly string dateCurrent;
        public BankTransaction(int sum)
        {
            dateCurrent = DateTime.Now.ToString();
            balance = sum;
        }
        public override string ToString()
        {
            return "Дата: " + dateCurrent + " Баланс: " + balance;
        }

    }


    public enum TypeAccount
    {
        current,
        savings
    };
}
