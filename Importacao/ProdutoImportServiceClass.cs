using System;

namespace Acessos
{
    public static class ValidacaoExtensions
    {
        public static bool IsValidAndPositive(this decimal? valor)
        {
            return valor.HasValue && valor.Value > 0;
        }

        public static bool IsValidAndNotNegative(this decimal? valor)
        {
            return valor.HasValue && valor.Value >= 0;
        }

        public static bool IsInRange(this decimal? valor, decimal min, decimal max)
        {
            return valor.HasValue && valor.Value >= min && valor.Value <= max;
        }

        public static bool IsValidDate(this DateTime? data)
        {
            return data.HasValue && data.Value >= new DateTime(1900, 1, 1) && data.Value <= DateTime.Now.AddYears(10);
        }

        public static bool IsFutureDate(this DateTime? data)
        {
            return data.HasValue && data.Value > DateTime.Today;
        }
    }

}
