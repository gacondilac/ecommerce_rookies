import "primeicons/primeicons.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.css";
import "primeflex/primeflex.css";
import "../../index.css";
import { getUserAPI } from "../../api/getapi";
import React, { useState, useEffect, useRef } from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Toast } from "primereact/toast";
import { Button } from "primereact/button";
import { Toolbar } from "primereact/toolbar";

import "../product/index.css";
//my code
const Customer = () => {
  const [customer, setCustomers] = useState([]);
  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    setCustomers(await getUserAPI());
  };

  //editing

  const toast = useRef(null);
  const dt = useRef(null);

  const exportCSV = () => {
    dt.current.exportCSV();
  };

  const rightToolbarTemplate = () => {
    return (
      <React.Fragment>
        <Button
          label="Export"
          icon="pi pi-upload"
          className="p-button-help"
          onClick={exportCSV}
        />
      </React.Fragment>
    );
  };

  const header = (
    <div className="table-header">
      <h5 className="mx-0 my-1">View Customers</h5>
    </div>
  );

  return (
    <div className="datatable-crud-demo">
      <Toast ref={toast} />

      <div className="card">
        <Toolbar className="mb-4" right={rightToolbarTemplate}></Toolbar>

        <DataTable
          ref={dt}
          value={customer}
          dataKey="id"
          paginator
          rows={10}
          rowsPerPageOptions={[5, 10, 25]}
          paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
          currentPageReportTemplate="Showing {first} to {last} of {totalRecords} customer"
          header={header}
          responsiveLayout="scroll"
        >
          <Column
            field="firstName"
            header="FirstName"
            sortable
            style={{ minWidth: "6rem" }}
          ></Column>
          <Column
            field="lastName"
            header="LastName"
            sortable
            style={{ minWidth: "6rem" }}
          ></Column>
          <Column
            field="email"
            header="Email"
            sortable
            style={{ minWidth: "8rem" }}
          ></Column>
          <Column
            field="phoneNumber"
            header="PhoneNumber"
            sortable
            style={{ minWidth: "8rem" }}
          ></Column>
        </DataTable>
      </div>
    </div>
  );
};

export default Customer;
