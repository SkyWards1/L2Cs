using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.util
{
    public static class Rnd
    {
        /**
         * Эта реализация происходит быстрее на параллельный доступ,
         * но может создавать тот же для 2 потоков.
         * @author SkyWard
         */
        public static readonly class NonAtomicRandom : Random
        {
            private static readonly long serialVersionUID = 1L;
            private volatile long _seed;

            public NonAtomicRandom()
            {
                this._seed = (++SEED_UNIQUIFIER + TimeSpan.TicksPerMillisecond);
            }

            public NonAtomicRandom(long seed)
            {
                setSeed(seed);
            }

            public readonly int next(int bits)
            {
                return (int) ((_seed = (_seed * MULTIPLIER + ADDEND) & MASK) >> (48 - bits));

            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public readonly void setSeed(long seed)
            {
                _seed = (seed ^ MULTIPLIER) & MASK;

            }
        }

        public static readonly class RandomContainer
        {
            private readonly Random _random;

            protected RandomContainer(Random random)
            {
                _random = random;
            }

            public readonly Random directRandom()
            {
                return _random;
            }

            /**
             * Получить случайное двойное число от 0 до 1
             * @return возвращает случайное двойное число от 0 до 1
             */
            public readonly double get()
            {
                return _random.NextDouble();
            }

            /**
             * Получает случайное целое число от 0(включительно) до n(exclusive)
             * @return возвращает случайное целое число от 0 до -1
             */
            public readonly int get(int n)
            {
                return (int)(_random.NextDouble() * n);
            }

            /**
             * Получает случайное целое число от min(включительно) до max(включительно)
             * @param min минимальное значение
             * @param max максимальное значение
             * @return возвращает случайное целое число от min до max
             */
            public readonly int get(int min, int max)
            {
                return min + (int)(_random.NextDouble() * (max - min + 1));
            }

            /**
             * Получает случайный длинный номер от мин(включительно) до max(включительно)
             * @param min минимальное значение
             * @param max максимальное значение
             * @return возвращает случайное длинное число от min до max
             */
            public readonly long get(long min, long max)
            {
                return min + (long)(_random.NextDouble() * (max - min + 1));
            }

            /**
             * Получить случайную логическое состояние (true или false)
             * @return возвращает случайное логическое состояние (true или false)
             */
           // public readonly Boolean nextBoolean()
          //  {
                //return _random;
          //  }

        }

        private readonly static long MULTIPLIER = 0x5DEECE66DL;
        private static long ADDEND = 0xBL;
        private readonly static long MASK = (1L << 48) - 1;
        protected static volatile long SEED_UNIQUIFIER = 8682522807148012L;
    }
}
