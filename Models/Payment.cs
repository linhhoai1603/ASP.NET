using System;

public class Payment
{

    int idPayment { get; set; }
    int idOrder { get; set; }
    int amount { get; set; }
    string status { get; set; }
    DateTime payment_date { get; set; }
    string payment_method { get; set; }
    public Payment(int idPayment, int idOrder, int amount, string status, DateTime payment_date, string payment_method)
    {
        this.idPayment = idPayment;
        this.idOrder = idOrder;
        this.amount = amount;
        this.status = status;
        this.payment_date = payment_date;
        this.payment_method = payment_method;
    }

}
