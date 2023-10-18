using ooplb4;

public class Program
{
    public static void Main(string[] args)
    {
        // Створюємо екосистему з 100 рослин, 10 тварин і 100 мікроорганізмів
        Ecosystem ecosystem = new Ecosystem();
        for (int i = 0; i < 100; i++)
        {
            ecosystem.Organisms.Add(new Plant());
        }
        for (int i = 0; i < 10; i++)
        {
            ecosystem.Organisms.Add(new Animal());
        }
        for (int i = 0; i < 100; i++)
        {
            ecosystem.Organisms.Add(new Microorganism());
        }

        // Запускаємо модель
        for (int i = 0; i < 100; i++)
        {
            ecosystem.Update();
        }

        // Виводимо кількість живих організмів в екосистемі
        Console.WriteLine("Кількість живих організмів: {0}", ecosystem.Organisms.Count);
    }

    // Базовий клас для живих організмів
    public abstract class LivingOrganism
    {
        public int Energy { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }

        public abstract void Eat();
        public abstract void Reproduce();
    }

    // Спадкоємні класи для тварин, рослин і мікроорганізмів
    public class Animal : LivingOrganism, IReproducible, IPredator
    {
        public int Speed { get; set; }
        public int Strength { get; set; }

        public void Eat()
        {
            // Живиться рослинами або іншими тваринами
        }

        public void Reproduce()
        {
            // Розмножується, створюючи дитинча
        }

        public void Hunt(LivingOrganism prey)
        {
            // Полює на іншу тварину
        }
    }

    public class Plant : LivingOrganism
    {
        public int PhotosynthesisRate { get; set; }

        public void Eat()
        {
            // Живиться сонячним світлом і водою
        }

        public void Reproduce()
        {
            // Розмножується, створюючи нову рослину
        }
    }

    public class Microorganism : LivingOrganism
    {
        public int ReproductionRate { get; set; }

        public void Eat()
        {
            // Живиться мертвою органічною речовиною
        }

        public void Reproduce()
        {
            // Розмножується, створюючи нових мікроорганізмів
        }
    }

    // Клас для моделювання екосистеми
    public class Ecosystem
    {
        public List<LivingOrganism> Organisms { get; set; }

        public void Update()
        {
            // Проходить по всіх організмах в екосистемі
            foreach (LivingOrganism organism in Organisms)
            {
                // Живиться
                organism.Eat();

                // Розмножується
                if (organism is IReproducible)
                {
                    (organism as IReproducible).Reproduce();
                }

                // Полює
                if (organism is IPredator)
                {
                    (organism as IPredator).Hunt(GetRandomOrganism());
                }
            }

            // Смерть організмів
            foreach (LivingOrganism organism in Organisms)
            {
                if (organism.Energy <= 0)
                {
                    // Організм помирає
                    Organisms.Remove(organism);
                }
            }
        }

        private LivingOrganism GetRandomOrganism()
        {
            // Повертає випадковий організм з екосистеми
            return Organisms[Random.Range(0, Organisms.Count)];
        }
    }

    // Приклад використання
    public class Program
    {
        public static void Main(string[] args)
        {
            // Створюємо екосистему з 100 рослин, 10 тварин і 100 мікроорганізмів
            Ecosystem ecosystem = new Ecosystem();
            for (int i = 0; i < 100; i++)
            {
                ecosystem.Organisms.Add(new Plant());
            }
            for (int i = 0; i < 10; i++)
            {
                ecosystem.Organisms.Add(new Animal());
            }
            for (int i = 0; i < 100; i++)
            {
                ecosystem.Organisms.Add(new Microorganism());
            }

            // Запускаємо модель
            for (int i = 0; i < 100; i++)
            {
                ecosystem.Update();
            }

            // Виводимо кількість живих організмів в екосистемі
            Console.WriteLine("Кількість живих організмів: {0}", ecosystem.Organisms.Count);
        }
    }

}
