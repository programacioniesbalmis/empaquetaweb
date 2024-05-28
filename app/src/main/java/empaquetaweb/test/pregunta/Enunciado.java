package empaquetaweb.test.pregunta;

import empaquetaweb.test.AdapterCDATA;
import jakarta.xml.bind.annotation.XmlAccessType;
import jakarta.xml.bind.annotation.XmlAccessorType;
import jakarta.xml.bind.annotation.XmlAttribute;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;
import jakarta.xml.bind.annotation.adapters.XmlJavaTypeAdapter;

@XmlRootElement(name = "questiontext")
@XmlAccessorType(XmlAccessType.FIELD)
public class Enunciado {
    public Enunciado(String texto) {
        setFormato("html");
        setTexto(texto);
    }

    @XmlAttribute(name="format")
    private String formato;

    @XmlElement(name="text")
    @XmlJavaTypeAdapter(AdapterCDATA.class)
    private String texto;

    public String getFormato() {
        return formato;
    }

    public void setFormato(String formato) {
        this.formato = formato;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }
}
