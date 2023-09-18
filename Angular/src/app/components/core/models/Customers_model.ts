/*Dejo todos los campos, ya que lo  ideal seria mostrar todos los datos solicitados
 pero utilizare pocos paraque la tabla no sea tan larga*/
export interface Customers {
    CustomerID:   number;
    CompanyName: string;
    ContactName: null | string;
    ContactTitle: null | string;
    address:      null | string;
    city:        null | string;
    country:     null | string;
    postalCode:  null | string;
    region:      null | string;
    Phone:       null | string;
    Fax:         null | string;

}