package empaquetaweb.test.pregunta;

import jakarta.xml.bind.annotation.XmlAccessType;
import jakarta.xml.bind.annotation.XmlAccessorType;
import jakarta.xml.bind.annotation.XmlAttribute;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name="question")
@XmlAccessorType(XmlAccessType.FIELD)
public class PreguntaMultiopcion {
    public PreguntaMultiopcion(
            int id,
            String enunciado
    ) {
        setTipo("multichoice");
        setCategoria(null);
        setNombre(new Nombre(String.format("Pregunta %d", id)));
        setEnunciado(new Enunciado(enunciado));
    }
    public PreguntaMultiopcion(Categoria categoria) {
        setTipo("category");
        setCategoria(categoria);
    }

    @XmlAttribute(name="type")
    private String tipo;

    @XmlElement(name="category")
    private Categoria categoria;

    @XmlElement(name="name")
    private Nombre nombre;

    @XmlElement(name="questiontext")
    private Enunciado enunciado;

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public Categoria getCategoria() {
        return categoria;
    }

    public void setCategoria(Categoria categoria) {
        this.categoria = categoria;
    }

    public Nombre getNombre() {
        return nombre;
    }

    public void setNombre(Nombre nombre) {
        this.nombre = nombre;
    }

    public Enunciado getEnunciado() {
        return enunciado;
    }

    public void setEnunciado(Enunciado enunciado) {
        this.enunciado = enunciado;
    }
}
