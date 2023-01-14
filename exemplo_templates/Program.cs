#if (matematica)
using exemplo_templates.matematica;
#endif

namespace alfa;

class Program
{
	public static void Main()
	{
		Console.WriteLine("O programa alfa foi criado");
		Console.WriteLine("Autor: nome");
#if (matematica)
		var mat = new Matematica();
		Console.WriteLine(mat.Soma(1,3));
#endif
#if (preto)
		Console.WriteLine("escolheu a cor preta");
#endif
#if (branco)
		Console.WriteLine("escolheu a cor branca");
#endif
#if (solinux)
		Console.WriteLine("Programa para Ubunto");
#endif
#if (sowindows)
		Console.WriteLine("Programa para Windows");
#endif
	}
}
