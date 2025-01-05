using System;

public class Payment
{

	int idPayment{get;set; }
    int idOrder { get; set; }
    string method { get; set; }
    string state { get; set; }
    DateTime datePayment { get; set; }

    public Payment(int idPayment, int idOrder, string method, string state, DateTime datePayment)
    {
        this.idPayment = idPayment;
        this.idOrder = idOrder;
        this.method = method;
        this.state = state;
        this.datePayment = datePayment;
    }

}
