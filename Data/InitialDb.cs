using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SummonerMatch.Data
{
    public static class InitialDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Asegurarse de que la base de datos esté creada
            context.Database.EnsureCreated();

            // Inicializar datos para TipoPartida
            InitializeTipoPartida(context);
            
            // Inicializar datos para Rango
            InitializeRango(context);

            // Inicializar datos para Posicion
            InitializePosicion(context);

            // Inicializar datos para Region
            InitializeRegion(context);
        }

        private static void InitializeTipoPartida(ApplicationDbContext context)
        {
            if (context.TipoPartida == null)
            {
                throw new InvalidOperationException("DbSet<TipoPartida> is null. Ensure it is correctly configured.");
            }

            // Verificar si ya hay datos en la tabla TipoPartida
            if (context.TipoPartida.Any())
            {
                return; // La base de datos ya ha sido inicializada
            }

            // Datos iniciales para TipoPartida
            var tiposPartida = new TipoPartida[]
            {
                new TipoPartida { NombreTipo = "casual" },
                new TipoPartida { NombreTipo = "ranked" },
                new TipoPartida { NombreTipo = "aram" }
            };

            foreach (var tipo in tiposPartida)
            {
                context.TipoPartida.Add(tipo);
            }

            // Guardar los cambios
            context.SaveChanges();
        }

        private static void InitializeRango(ApplicationDbContext context)
        {
            if (context.Rango == null)
            {
                throw new InvalidOperationException("DbSet<Rango> is null. Ensure it is correctly configured.");
            }

            // Verificar si ya hay datos en la tabla Rango
            if (context.Rango.Any())
            {
                return; // La base de datos ya ha sido inicializada
            }

            // Datos iniciales para Rango (rangos de League of Legends)
            var rangos = new Rango[]
            {
                new Rango { NombreRango = "iron" },
                new Rango { NombreRango = "bronze" },
                new Rango { NombreRango = "silver" },
                new Rango { NombreRango = "gold" },
                new Rango { NombreRango = "platinum" },
                new Rango { NombreRango = "emerald" },
                new Rango { NombreRango = "diamond" },
                new Rango { NombreRango = "master" },
                new Rango { NombreRango = "grandMaster" },
                new Rango { NombreRango = "challenger" },
            };

            foreach (var rango in rangos)
            {
                context.Rango.Add(rango);
            }

            // Guardar los cambios
            context.SaveChanges();
        }

        private static void InitializePosicion(ApplicationDbContext context)
        {
            if (context.Posicion == null)
            {
                throw new InvalidOperationException("DbSet<Posicion> is null. Ensure it is correctly configured.");
            }

            // Verificar si ya hay datos en la tabla Posicion
            if (context.Posicion.Any())
            {
                return;   // La base de datos ya ha sido inicializada
            }

            // Datos iniciales para Posicion
            var posiciones = new Posicion[]
            {
                new Posicion { NombrePosicion = "top" },
                new Posicion { NombrePosicion = "jungle" },
                new Posicion { NombrePosicion = "mid" },
                new Posicion { NombrePosicion = "support" },
                new Posicion { NombrePosicion = "adc" }
            };

            foreach (var posicion in posiciones)
            {
                context.Posicion.Add(posicion);
            }

            // Guardar los cambios
            context.SaveChanges();
        }

        private static void InitializeRegion(ApplicationDbContext context)
        {
            if (context.Region == null)
            {
                throw new InvalidOperationException("DbSet<Region> is null. Ensure it is correctly configured.");
            }

            // Verificar si ya hay datos en la tabla Region
            if (context.Region.Any())
            {
                return;   // La base de datos ya ha sido inicializada
            }

            // Datos iniciales para Region
            var regiones = new Region[]
            {
                new Region { NombreRegion = "NA" },  // Norteamérica
                new Region { NombreRegion = "EUW" }, // Europa Occidental
                new Region { NombreRegion = "EUNE" }, // Europa Nórdica y del Este
                new Region { NombreRegion = "KR" },  // Corea
                new Region { NombreRegion = "CN" },  // China
                new Region { NombreRegion = "JP" },  // Japón
                new Region { NombreRegion = "BR" },  // Brasil
                new Region { NombreRegion = "LAN" }, // Latinoamérica Norte
                new Region { NombreRegion = "LAS" }, // Latinoamérica Sur
                new Region { NombreRegion = "OCE" }, // Oceanía
                new Region { NombreRegion = "TR" },  // Turquía
                new Region { NombreRegion = "RU" }   // Rusia
            };

            foreach (var region in regiones)
            {
                context.Region.Add(region);
            }

            // Guardar los cambios
            context.SaveChanges();
        }
    }
}
