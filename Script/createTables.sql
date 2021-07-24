CREATE TABLE tblFacturas(
    IdFactura           ROWID,
    NumeroFactura       VARCHAR2(10),
    Fecha               DATE Default SYSDATE,
    TipoPago            NUMBER(2),
    DocumentoCliente    NUMBER(10),
    NombreCliente       VARCHAR2(100),
    SubTotal            NUMBER(11,2),
    Descuento           NUMBER(5,2),
    Iva                 NUMBER(4,2),
    TotalDescuento      NUMBER(7,2),
    TotalImpuesto       NUMBER(8,2),
    Total               NUMBER(12,2)

    CONSTRAINT facturas_pk PRIMARY KEY(IdFactura)
);

CREATE TABLE tblProductos(
    IdProducto  ROWID,
    IdFactura   ROWID,
    Producto    VARCHAR2(100)

    CONSTRAINT productos_pk PRIMARY KEY(IdProducto)
    CONSTRAINT factura_fk FOREIGN KEY (IdFactura) REFERENCES tblFacturas (IdFactura)
);
