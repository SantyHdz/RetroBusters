var Lista_miembros = new List<Miembros>();
var Lista_empleados = new List<Empleados>();
var Lista_envios = new List<Envios>();
var Lista_reservas = new List<Reservas>();
var Lista_peliculas = new List<Peliculas>();
var lista_snacks = new List<Snacks>();
var lista_consolas = new List<Consolas>();
var lista_bodegas = new List<Almacenes>();

// Llenado de Bodegas (Almacenes)
lista_bodegas.Add(new Almacenes { 
    Id_bodega = 1, 
    Ubicacion_bodega = "Bodega Central", 
    Capacidad_bodega = 1000 
});

lista_bodegas.Add(new Almacenes { 
    Id_bodega = 2, 
    Ubicacion_bodega = "Bodega Norte", 
    Capacidad_bodega = 750 
});

// Llenado de Consolas
lista_consolas.Add(new Consolas { 
    Id_consola = 1, 
    Tipo_consola = "PlayStation 5", 
    Marca_consola = "Sony", 
    Estado_consola = 1,
    _almacen = lista_bodegas[0]
});

lista_consolas.Add(new Consolas { 
    Id_consola = 2, 
    Tipo_consola = "Xbox Series X", 
    Marca_consola = "Microsoft", 
    Estado_consola = 1,
    _almacen = lista_bodegas[1]
});

// Llenado de Películas
Lista_peliculas.Add(new Peliculas { 
    Id_pelicula = 1, 
    Nombre_pelicula = "Avengers: Endgame", 
    Genero_Pelicula = "Acción", 
    Fecha_Estreno = new DateTime(2019, 4, 26), 
    Estado_pelicula = true 
});

Lista_peliculas.Add(new Peliculas { 
    Id_pelicula = 2, 
    Nombre_pelicula = "Toy Story 4", 
    Genero_Pelicula = "Animación", 
    Fecha_Estreno = new DateTime(2019, 6, 21), 
    Estado_pelicula = true 
});

// Llenado de Snacks
lista_snacks.Add(new Snacks { 
    Id = 1, 
    Nombre = "Palomitas Grandes", 
    Precio = 4.99f, 
    Stock = 50 
});

lista_snacks.Add(new Snacks { 
    Id = 2, 
    Nombre = "Refresco 500ml", 
    Precio = 2.99f, 
    Stock = 100 
});

// Llenado de Empleados
var empleado1 = new Empleados { 
    Id_empleados = 1, 
    Nombre_empleado = "Carlos Martínez", 
    Cargo_empleado = "Gerente", 
    Sueldo = 45000, 
    Fecha_contratacion = new DateTime(2018, 3, 15),
    reservas = new List<Reservas>(),
    envios = new List<Envios>()
};

var empleado2 = new Empleados { 
    Id_empleados = 2, 
    Nombre_empleado = "María González", 
    Cargo_empleado = "Asistente", 
    Sueldo = 25000, 
    Fecha_contratacion = new DateTime(2022, 8, 1),
    reservas = new List<Reservas>(),
    envios = new List<Envios>()
};

Lista_empleados.Add(empleado1);
Lista_empleados.Add(empleado2);

// Llenado de Miembros
Lista_miembros.Add(new Miembros { 
    Id_miembros = 1, 
    Nombre = "Ana López", 
    Fecha_registro = new DateTime(2023, 1, 15), 
    Nivel = "Oro", 
    Puntos = 2450 
});

Lista_miembros.Add(new Miembros { 
    Id_miembros = 2, 
    Nombre = "Pedro Sánchez", 
    Fecha_registro = new DateTime(2024, 3, 1), 
    Nivel = "Plata", 
    Puntos = 1350 
});

// Llenado de Reservas
var reserva1 = new Reservas {
    Id = 1,
    Fecha_Reserva = DateTime.Now.AddDays(-3),
    Estado = "Activa",
    Miembro = Lista_miembros[0],
    Pelicula = Lista_peliculas[0],
    Consola = lista_consolas[0],
    Empleado = empleado1,
    Reservas_Snacks = new List<Reservas_Snacks>()
};

var snackReserva1 = new Reservas_Snacks {
    Snack = lista_snacks[0],
    Reserva = reserva1.Id
};

reserva1.Reservas_Snacks.Add(snackReserva1);
empleado1.reservas.Add(reserva1);
Lista_reservas.Add(reserva1);

// Llenado de Envíos
var envio1 = new Envios { 
    Id_envios = 1, 
    Estado = "En tránsito", 
    Direccion = "Calle Principal 123", 
    Transportadora = "DHL",
    _empleado = empleado2
};

empleado2.envios.Add(envio1);
Lista_envios.Add(envio1);

public class Miembros
{
    public int Id_miembros { get; set; }
    public string? Nombre { get; set; }
    public DateTime Fecha_registro { get; set; }
    public string? Nivel { get; set; }
    public int Puntos { get; set; }
    public List<Reservas>? reservas { get; set; }
}

public class Empleados
{
    public int Id_empleados { get; set; }
    public string? Nombre_empleado { get; set; }
    public string? Cargo_empleado { get; set; }
    public double Sueldo { get; set; }
    public DateTime Fecha_contratacion { get; set; }
    public List<Reservas>? reservas { get; set; }
    public List<Envios>? envios { get; set; }
}

public class Envios
{
    public int Id_envios { get; set; }  
    public string? Estado { get; set; }
    public string? Direccion { get; set; }
    public string? Transportadora { get; set; }
    public int empleados { get; set; }
    public Empleados? _empleado { get; set; }
}

public class Reservas
{
    public int Id { get; set; }
    public DateTime Fecha_Reserva { get; set; }
    public string? Estado { get; set; }
    public Miembros? Miembro { get; set; }
    public Peliculas? Pelicula { get; set; }
    public Consolas? Consola { get; set; }
    public Empleados? Empleado { get; set; }
    public List<Reservas_Snacks>? Reservas_Snacks { get; set; }
}

public class Peliculas
{
    public int Id_pelicula { get; set; }
    public string? Nombre_pelicula { get; set; }
    public string? Genero_Pelicula { get; set; }
    public DateTime Fecha_Estreno { get; set; }
    public bool Estado_pelicula { get; set; }
    public List<Reservas>? reserva { get; set; }
}

public class Consolas
{
    public int Id_consola { get; set; }
    public string? Tipo_consola { get; set; }
    public string? Marca_consola { get; set; }
    public int Estado_consola { get; set; }
    public int almacen { get; set; }
    public Almacenes? _almacen  { get; set; }
    public List<Reservas>? reserva { get; set; }
}

public class Snacks
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public float Precio { get; set; }
    public int Stock { get; set; }
    public List<Reservas_Snacks>? Reservas_Snacks { get; set; }
}

public class Reservas_Snacks
{
    public int Id { get; set; }
    public int SnackId { get; set; }
    public Snacks? Snack { get; set; }
    public int Reserva { get; set; }
    public Reservas? _Reserva { get; set; }
}

public class Almacenes
{
    public int Id_bodega { get; set; }
    public string? Ubicacion_bodega { get; set; }
    public double Capacidad_bodega { get; set; }
}
 // suponiendo que agregue cosas nuevas