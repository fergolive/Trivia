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
    internal class LogicaJuego : ILogicaJuego
    {

        private static LogicaJuego miInstancia = null;
        private LogicaJuego() { }

        public static ILogicaJuego GetMiInstancia()
        {

            if (miInstancia == null)
                miInstancia = new LogicaJuego();

            return miInstancia;
        }

        private Persistencia.IPersistenciaJuego unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaJuego();


        public Juego Alta_Juego(Juego j)
        {

            return (unaPersistencia.Alta_Juego(j));

        }

        public void Baja_Juego(Juego j)
        {

            unaPersistencia.Baja_Juego(j);

        }

        public void Modificacion_Juego(Juego j)
        {

            unaPersistencia.Modificacion_Juego(j);

        }

        public Juego Buscar_Juego(int numJuego)
        {

            return unaPersistencia.Buscar_Juego(numJuego);

        
        }

        public List<Juego> Buscar_Juegos_xJugador(int documento)
        {
            return unaPersistencia.Buscar_Juegos_xJugador(documento);
        }

        public List<Juego> Listar_Juego()
        {

            return (unaPersistencia.Listar_Juego());

        }

        public XmlDocument ObtenerDocumentoXmlJuego() //cambiarlo a un metodo del web service 
        {
            try
            {
                //obtengo la lista de juegos finalizados desde la base de datos
                List<Juego> JuegosFinalizados = Persistencia.FabricaPersistencia.getPersistenciaJuego().ListarJuegosFinalizados();

                XmlDocument Nuevo_XML = new XmlDocument();
                Nuevo_XML.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <JuegosFinalizados></JuegosFinalizados>");
                XmlNode raizService = Nuevo_XML.DocumentElement;

                
                foreach (Juego juego in JuegosFinalizados )
                {
                    //creo un documento xml y su nodo raiz


                    // Juego  -------------------------------------------------------

                    XmlElement _Juego = Nuevo_XML.CreateElement("Juego");

                    // Datos del juego  -------------------------------------------------------
                    //creo un nodo por dato de juego
                    XmlElement _Numero = Nuevo_XML.CreateElement("Numero");
                    _Numero.InnerText = juego.Numero.ToString();
                    XmlElement _FechaHoraInicio = Nuevo_XML.CreateElement("FechaHoraInicio");
                    _FechaHoraInicio.InnerText = juego.FechaHoraInicio .ToString();
                    XmlElement _FechaHoraFinal = Nuevo_XML.CreateElement("FechaHoraFinal");
                    _FechaHoraFinal.InnerText = juego.FechaHoraFinal.ToString();
                    XmlElement _CantMovimientos = Nuevo_XML.CreateElement("cantMovimientos");
                    _CantMovimientos.InnerText = juego.CantMovimientos.ToString();
                    XmlElement _ContestacionesOk = Nuevo_XML.CreateElement("ContestacionesOk");
                    _ContestacionesOk.InnerText = juego.ContestacionesOK.ToString();
                    XmlElement _NumJugador = Nuevo_XML.CreateElement("Jugador");
                    _NumJugador.InnerText = juego.Player.NomPublico.ToString();
                    XmlElement _Preguntas = Nuevo_XML.CreateElement("Preguntas");

                    String textoPreguntas="";
                    int i = 1;
                    foreach(Pregunta p in juego.Preguntas)
                    {
                        textoPreguntas += i + ") " + p.Texto+" / ";
                        i += 1;
                    }

                    _Preguntas.InnerText = textoPreguntas;

                    /*
                    XmlElement _Preguntas = Nuevo_XML.CreateElement("Preguntas");

                        XmlElement _Pregunta1 = Nuevo_XML.CreateElement("Pregunta1");
                        _Pregunta1.InnerText = juego.Preguntas[0].Texto.ToString();
                        XmlElement _Pregunta2 = Nuevo_XML.CreateElement("Pregunta2");
                        _Pregunta2.InnerText = juego.Preguntas[1].Texto.ToString();
                        XmlElement _Pregunta3 = Nuevo_XML.CreateElement("Pregunta3");
                        _Pregunta3.InnerText = juego.Preguntas[2].Texto.ToString();
                        XmlElement _Pregunta4 = Nuevo_XML.CreateElement("Pregunta4");
                        _Pregunta4.InnerText = juego.Preguntas[3].Texto.ToString();
                        XmlElement _Pregunta5 = Nuevo_XML.CreateElement("Pregunta5");
                        _Pregunta5.InnerText = juego.Preguntas[4].Texto.ToString();
                        XmlElement _Pregunta6 = Nuevo_XML.CreateElement("Pregunta6");
                        _Pregunta6.InnerText = juego.Preguntas[5].Texto.ToString();
                        XmlElement _Pregunta7 = Nuevo_XML.CreateElement("Pregunta7");
                        _Pregunta7.InnerText = juego.Preguntas[6].Texto.ToString();
                        XmlElement _Pregunta8 = Nuevo_XML.CreateElement("Pregunta8");
                        _Pregunta8.InnerText = juego.Preguntas[7].Texto.ToString();
                        XmlElement _Pregunta9 = Nuevo_XML.CreateElement("Pregunta9");
                        _Pregunta9.InnerText = juego.Preguntas[8].Texto.ToString();

                    //agrego al nodo _Preguntas sus nodos hijos  (9 preguntas)
                        _Preguntas.AppendChild(_Pregunta1);
                        _Preguntas.AppendChild(_Pregunta2);
                        _Preguntas.AppendChild(_Pregunta3);
                        _Preguntas.AppendChild(_Pregunta4);
                        _Preguntas.AppendChild(_Pregunta5);
                        _Preguntas.AppendChild(_Pregunta6);
                        _Preguntas.AppendChild(_Pregunta7);
                        _Preguntas.AppendChild(_Pregunta8);
                        _Preguntas.AppendChild(_Pregunta9);

                    //agrego al nodo _Juego sus nodos hijos
                    
                     */
                    _Juego.AppendChild(_Numero);
                    _Juego.AppendChild(_FechaHoraInicio);
                    _Juego.AppendChild(_FechaHoraFinal);
                    _Juego.AppendChild(_CantMovimientos);
                    _Juego.AppendChild(_ContestacionesOk);
                    _Juego.AppendChild(_NumJugador);
                    _Juego.AppendChild(_Preguntas);

                    //el nodo raiz agrega a su nodos hijos que son juegos 
                    raizService.AppendChild(_Juego);

                } //fin del foreach

                return Nuevo_XML;

            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public bool ComprobarDisponibilidadDeJuego(int Documento)
        { 
        
             return unaPersistencia.ComprobarDisponibilidadDeJuego(Documento);
        }

        public Juego Buscar_Juego_Pendiente(int documento)
        {
            return unaPersistencia.Buscar_Juego_Pendiente(documento);
        }

        public void Guardar_Juego(Juego juego, bool finalizado)
        {
            unaPersistencia.Guardar_Juego(juego, finalizado);
        }

        public List<int> Buscar_Estado_Juego(int numeroJuego)
        { 
            return unaPersistencia.Buscar_Estado_Juego(numeroJuego);
        }
    }
}