package empaquetaweb.test;

import jakarta.xml.bind.annotation.adapters.XmlAdapter;

public class AdapterCDATA extends XmlAdapter<String, String> {
    public String unmarshal(String v) {
        return v;
    }

    public String marshal(String v) {
        return "<![CDATA[\n" + v + "\n]]>";
    }
}
