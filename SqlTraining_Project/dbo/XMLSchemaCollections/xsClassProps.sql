CREATE XML SCHEMA COLLECTION [dbo].[xsClassProps2]
    AS N'<xsd:schema xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <xsd:element name="clsClassProp">
    <xsd:complexType>
      <xsd:complexContent>
        <xsd:restriction base="xsd:anyType">
          <xsd:sequence>
            <xsd:element name="name" type="xsd:string" />
            <xsd:element name="arrayIndex" type="xsd:integer" />
            <xsd:element name="parentKey" type="xsd:integer" />
            <xsd:element name="key" type="xsd:integer" />
          </xsd:sequence>
        </xsd:restriction>
      </xsd:complexContent>
    </xsd:complexType>
  </xsd:element>
</xsd:schema>';

