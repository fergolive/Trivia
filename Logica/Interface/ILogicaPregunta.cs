using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaPregunta
    {
        int Alta_Pregunta(Pregunta p);
        void Baja_Pregunta(Pregunta p);
        void Modificacion_Pregunta(Pregunta p);
		Pregunta Buscar_Pregunta(int num);
        List<Pregunta> Buscar_Preguntas(int numJuego);
		List<Pregunta> Listar_Pregunta();

    }
}
