package empaquetaweb.test.pregunta;

import jakarta.xml.bind.annotation.XmlAccessType;
import jakarta.xml.bind.annotation.XmlAccessorType;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "name")
@XmlAccessorType(XmlAccessType.FIELD)
public class Nombre {
    public Nombre(String texto) {
        setTexto(texto);
    }

    @XmlElement(name = "text")
    private String texto;

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }
}
