import "primeicons/primeicons.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.css";
import "primeflex/primeflex.css";
import "../../index.css";
import {
  addCategoryAPI,
  delCategoryAPI,
  editCategoryAPI,
  getCategoryAPI,
} from "../../api/getapi";
import React, { useState, useEffect, useRef } from "react";
import { classNames } from "primereact/utils";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

import { Toast } from "primereact/toast";
import { Button } from "primereact/button";
import { Toolbar } from "primereact/toolbar";

import { Dialog } from "primereact/dialog";
import { InputText } from "primereact/inputtext";
import "../product/index.css";
//my code
const Categories = () => {
  let emptyCategory = {
    id: null,
    name: "",
  };
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    setCategories(await getCategoryAPI());
  };

  //editing

  const [categoryDialog, setCategoryDialog] = useState(false);
  const [deleteCategoryDialog, setDeleteCategoryDialog] = useState(false);
  const [deleteCategoriesDialog, setDeleteCategoriesDialog] = useState(false);
  const [category, setCategory] = useState(emptyCategory);
  const [selectedCategories, setSelectedCategories] = useState(null);
  const [submitted, setSubmitted] = useState(false);
  const [globalFilter, setGlobalFilter] = useState(null);
  const toast = useRef(null);
  const dt = useRef(null);

  const openNew = () => {
    setCategory(emptyCategory);
    setSubmitted(false);
    setCategoryDialog(true);
  };

  const hideDialog = () => {
    setSubmitted(false);
    setCategoryDialog(false);
  };

  const hideDeleteCategoryDialog = () => {
    setDeleteCategoryDialog(false);
  };

  const hideDeleteCategoriesDialog = () => {
    setDeleteCategoriesDialog(false);
  };

  const saveProduct = async () => {
    setSubmitted(true);

    if (category.name.trim()) {
      let _categories = [...categories];
      let _category = { ...category };
      if (category.id) {
        const index = findIndexById(category.id);

        _categories[index] = _category;
        await editCategoryAPI(_category);
        toast.current.show({
          severity: "success",
          summary: "Successful",
          detail: "Category Updated",
          life: 3000,
        });
      } else {
        await addCategoryAPI({
          name: category.name,
        }).then((Response) => {
          _category.id = Response.id;
          _category.categoryName = Response.categoryName;
          _categories.push(_category);
        });

        toast.current.show({
          severity: "success",
          summary: "Successful",
          detail: "Category Created",
          life: 3000,
        });
        //window.location.reload();
      }
      setCategories(_categories);
      setCategoryDialog(false);
      setCategory(emptyCategory);
    }
  };

  const editCategory = (category) => {
    setCategory({ ...category });
    setCategoryDialog(true);
  };

  const confirmDeleteCategory = (category) => {
    setCategory(category);
    setDeleteCategoryDialog(true);
  };

  const deleteCategory = async () => {
    let _categories = categories.filter((val) => val.id !== category.id);
    await delCategoryAPI(category.id);
    setCategories(_categories);
    setDeleteCategoryDialog(false);
    setCategory(emptyCategory);
    toast.current.show({
      severity: "success",
      summary: "Successful",
      detail: "Category Deleted",
      life: 3000,
    });
  };

  const findIndexById = (id) => {
    let index = -1;
    for (let i = 0; i < categories.length; i++) {
      if (categories[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  };

  const exportCSV = () => {
    dt.current.exportCSV();
  };

  const confirmDeleteSelected = () => {
    setDeleteCategoriesDialog(true);
  };

  const deleteSelectedCategories = () => {
    let _categories = categories.filter(
      (val) => !selectedCategories.includes(val)
    );
    setCategories(_categories);
    setDeleteCategoriesDialog(false);
    setSelectedCategories(null);
    toast.current.show({
      severity: "success",
      summary: "Successful",
      detail: "Products Deleted",
      life: 3000,
    });
  };

  const onInputChange = (e, name) => {
    const val = (e.target && e.target.value) || "";
    let _category = { ...category };
    _category[`${name}`] = val;

    setCategory(_category);
  };

  const leftToolbarTemplate = () => {
    return (
      <React.Fragment>
        <Button
          label="New"
          icon="pi pi-plus"
          className="p-button-success mr-2"
          onClick={openNew}
        />
        <Button
          label="Delete"
          icon="pi pi-trash"
          className="p-button-danger"
          onClick={confirmDeleteSelected}
          disabled={!selectedCategories || !selectedCategories.length}
        />
      </React.Fragment>
    );
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

  const actionBodyTemplate = (rowData) => {
    return (
      <React.Fragment>
        <Button
          icon="pi pi-pencil"
          className="p-button-rounded p-button-success mr-2"
          onClick={() => editCategory(rowData)}
        />
        <Button
          icon="pi pi-trash"
          className="p-button-rounded p-button-warning"
          onClick={() => confirmDeleteCategory(rowData)}
        />
      </React.Fragment>
    );
  };

  const header = (
    <div className="table-header">
      <h5 className="mx-0 my-1">Manage Categories</h5>
      <span className="p-input-icon-left">
        <i className="pi pi-search" />
        <InputText
          type="search"
          onInput={(e) => setGlobalFilter(e.target.value)}
          placeholder="Search..."
        />
      </span>
    </div>
  );
  const categoryDialogFooter = (
    <React.Fragment>
      <Button
        label="Cancel"
        icon="pi pi-times"
        className="p-button-text"
        onClick={hideDialog}
      />
      <Button
        label="Save"
        icon="pi pi-check"
        className="p-button-text"
        onClick={saveProduct}
      />
    </React.Fragment>
  );
  const deleteCategoryDialogFooter = (
    <React.Fragment>
      <Button
        label="No"
        icon="pi pi-times"
        className="p-button-text"
        onClick={hideDeleteCategoryDialog}
      />
      <Button
        label="Yes"
        icon="pi pi-check"
        className="p-button-text"
        onClick={deleteCategory}
      />
    </React.Fragment>
  );
  const deleteProductsDialogFooter = (
    <React.Fragment>
      <Button
        label="No"
        icon="pi pi-times"
        className="p-button-text"
        onClick={hideDeleteCategoriesDialog}
      />
      <Button
        label="Yes"
        icon="pi pi-check"
        className="p-button-text"
        onClick={deleteSelectedCategories}
      />
    </React.Fragment>
  );

  return (
    <div className="datatable-crud-demo">
      <Toast ref={toast} />

      <div className="card">
        <Toolbar
          className="mb-4"
          left={leftToolbarTemplate}
          right={rightToolbarTemplate}
        ></Toolbar>

        <DataTable
          ref={dt}
          value={categories}
          selection={selectedCategories}
          onSelectionChange={(e) => setSelectedCategories(e.value)}
          dataKey="id"
          paginator
          rows={10}
          rowsPerPageOptions={[5, 10, 25]}
          paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
          currentPageReportTemplate="Showing {first} to {last} of {totalRecords} categories"
          globalFilter={globalFilter}
          header={header}
          responsiveLayout="scroll"
        >
          <Column
            selectionMode="multiple"
            headerStyle={{ width: "3rem" }}
            exportable={false}
          ></Column>
          <Column
            field="id"
            header="Id"
            headerStyle={{ width: "3rem" }}
          ></Column>
          <Column
            field="name"
            header="Name"
            sortable
            style={{ minWidth: "55rem" }}
          ></Column>

          <Column
            body={actionBodyTemplate}
            exportable={false}
            style={{ minWidth: "4rem" }}
          ></Column>
        </DataTable>
      </div>

      <Dialog
        visible={categoryDialog}
        style={{ width: "450px" }}
        header="Category Details"
        modal
        className="p-fluid"
        footer={categoryDialogFooter}
        onHide={hideDialog}
      >
        <div className="field">
          <label htmlFor="name">Name</label>
          <InputText
            id="name"
            value={category.name}
            onChange={(e) => onInputChange(e, "name")}
            required
            autoFocus
            className={classNames({ "p-invalid": submitted && !category.name })}
          />
          {submitted && !category.name && (
            <small className="p-error">Name is required.</small>
          )}
        </div>
      </Dialog>

      <Dialog
        visible={deleteCategoryDialog}
        style={{ width: "450px" }}
        header="Confirm"
        modal
        footer={deleteCategoryDialogFooter}
        onHide={hideDeleteCategoryDialog}
      >
        <div className="confirmation-content">
          <i
            className="pi pi-exclamation-triangle mr-3"
            style={{ fontSize: "2rem" }}
          />
          {category && (
            <span>
              Are you sure you want to delete <b>{category.name}</b>?
            </span>
          )}
        </div>
      </Dialog>

      <Dialog
        visible={deleteCategoriesDialog}
        style={{ width: "450px" }}
        header="Confirm"
        modal
        footer={deleteProductsDialogFooter}
        onHide={hideDeleteCategoriesDialog}
      >
        <div className="confirmation-content">
          <i
            className="pi pi-exclamation-triangle mr-3"
            style={{ fontSize: "2rem" }}
          />
          {category && (
            <span>
              Are you sure you want to delete the selected categories?
            </span>
          )}
        </div>
      </Dialog>
    </div>
  );
};

export default Categories;
