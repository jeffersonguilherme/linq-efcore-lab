namespace LinqEfCoreLab.Entities;

public class Cliente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Cpf { get; private set; } = string.Empty;
    public DateTime DataCadastro { get; private set; }
    public bool Ativo { get; private set; }

    public ICollection<Pedido> Pedidos { get; private set; } = new List<Pedido>();
    protected Cliente() {}

    public static Cliente Create(
        string nome,
        string email,
        string cpf,
        bool ativo
    )
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Email = email,
            Cpf = cpf,
            Ativo = ativo,
            DataCadastro = DateTime.UtcNow
        };
        return cliente;
    }

        public void Update(
        string nome,
        string email,
        string cpf,
        bool ativo
    )
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Ativo = ativo;
    }

    }