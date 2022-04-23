using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace Logica
{
    public interface ILogicaJuego
    {
        Juego Alta_Juego(Juego j);
        void Baja_Juego(Juego j);
        void Modificacion_Juego(Juego j);
		Juego Buscar_Juego(int numJuego);
		List<Juego> Listar_Juego();
        XmlDocument ObtenerDocumentoXmlJuego();
        List<Juego> Buscar_Juegos_xJugador(int documento);
        bool ComprobarDisponibilidadDeJuego(int Documento);
        Juego Buscar_Juego_Pendiente(int documento);
        void Guardar_Juego(Juego juego,bool finalizado);
        List<int> Buscar_Estado_Juego(int numeroJuego);
    }
}
