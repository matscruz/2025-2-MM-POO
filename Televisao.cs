public class Televisao
{
    public const int VOLUME_MINIMO = 0;
    public const int VOLUME_MAXIMO = 100;
    public const int CANAL_MINIMO = 1;
    public const int CANAL_MAXIMO = 520;

    private int volume;
    private int volumeAnterior; // Armazena o volume antes de ativar o mudo
    private int canal;
    private int ultimoCanalAssistido; // Armazena o último canal assistido
    private bool mudo;

    public Televisao(float tamanho)
    {
        Tamanho = tamanho;
        Estado = false;
        volume = 10;
        volumeAnterior = volume;
        canal = CANAL_MINIMO;
        ultimoCanalAssistido = CANAL_MINIMO;
        mudo = false;
    }

    public float Tamanho { get; set; }
    public bool Estado { get; private set; }

    public int Volume
    {
        get => mudo ? 0 : volume;
        private set
        {
            if (value < VOLUME_MINIMO)
                volume = VOLUME_MINIMO;
            else if (value > VOLUME_MAXIMO)
                volume = VOLUME_MAXIMO;
            else
                volume = value;
        }
    }

    public int Canal
    {
        get => canal;
        private set
        {
            if (value >= CANAL_MINIMO && value <= CANAL_MAXIMO)
            {
                canal = value;
            }
        }
    }

    public void Ligar()
    {
        Estado = true;
        canal = ultimoCanalAssistido; // Retorna ao último canal assistido ao ligar
        DesativarMudo();
    }

    public void Desligar()
    {
        Estado = false;
    }

    public void AumentarVolume()
    {
        if (!mudo)
        {
            Volume = volume + 1;
        }
    }

    public void ReduzirVolume()
    {
        if (!mudo)
        {
            Volume = volume - 1;
        }
    }

    public void AtivarMudo()
    {
        if (!mudo)
        {
            volumeAnterior = volume;
            mudo = true;
        }
    }

    public void DesativarMudo()
    {
        if (mudo)
        {
            mudo = false;
            volume = volumeAnterior;
        }
    }

    public void AumentarCanal()
    {
        if (canal < CANAL_MAXIMO)
        {
            Canal = canal + 1;
        }
        else
        {
            Canal = CANAL_MINIMO; // Loop para o primeiro canal
        }
        ultimoCanalAssistido = Canal;
    }

    public void ReduzirCanal()
    {
        if (canal > CANAL_MINIMO)
        {
            Canal = canal - 1;
        }
        else
        {
            Canal = CANAL_MAXIMO; // Loop para o último canal
        }
        ultimoCanalAssistido = Canal;
    }

    public void IrParaCanal(int numeroDoCanal)
    {
        if (numeroDoCanal >= CANAL_MINIMO && numeroDoCanal <= CANAL_MAXIMO)
        {
            Canal = numeroDoCanal;
            ultimoCanalAssistido = Canal;
        }
    }

    public void DefinirVolume(int novoVolume)
    {
        Volume = novoVolume;
        if (mudo)
        {
            DesativarMudo();
        }
    }
}