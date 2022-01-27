var restClient = {
    getCategories: (search) =>{
        return new Promise((resolve, reject)=>{
            $.ajax({
                url: "/api/selects/categories/" + search,
                success: function (data)
                {
                    resolve(data.categories)
                },
                error: function ()
                {
                    reject()
                }
            })
        })
    },
    createCategory: (categoryName) =>{
        return new Promise((resolve, reject)=>{
            $.ajax({
                url: "/api/selects/categories/",
                method: "POST",
                data: JSON.stringify({ "name": categoryName }),
                contentType: 'application/json',
                success: function (data)
                {
                    resolve(data.id)
                },
                error: function ()
                {
                    reject()
                }
            })
        })
    },
    getOperationTemplates: (search) =>{
        return new Promise((resolve, reject)=>{
            $.ajax({
                url: "/api/selects/operation-templates/" + search,
                success: function (data)
                {
                    resolve(data.operationTemplates)
                },
                error: function ()
                {
                    reject()
                }
            })
        })
    },
    createOperation: (operationTemplateId, budgetId) =>{
        return new Promise((resolve, reject)=>{
            $.ajax({
                url: "/api/selects/operation/",
                method: "POST",
                data: JSON.stringify({ "operationTemplateId": operationTemplateId, "budgetId": budgetId }),
                contentType: 'application/json',
                success: function ()
                {
                    resolve()
                },
                error: function ()
                {
                    reject()
                }
            })
        })
    },
}

class SelectSearch
{
    state = {
        choosen: {
            id: "",
            name: "",
            isNew: false
        },
        searchResult: []
    }
    
    constructor(domElement) {
        this.domElement=$(domElement)
        this.state.choosen.name = $(this.domElement.find(".category-input")[0]).val()
        this.state.choosen.id = $(this.domElement.find("input[name=OperationCategoryId]")[0]).val()
        this.update()
    }
    
    setState(newState)
    {
        this.state = newState;
        console.log(this.state)
        this.update();
    }
    
    async onInput(e)
    {
        let categories = await restClient.getCategories(e.target.value)
            .catch(()=>{})
        let existingCategory = categories != null && categories.length >0 ? categories.filter(x => x.name === e.target.value)[0] : null
        this.setState({
            choosen: {
                id: existingCategory != null ? existingCategory.id : "",
                name: e.target.value,
                isNew: existingCategory == null && e.target.value !== ""
            },
            searchResult: categories == null ? [] : categories
        })
    }
    
    async addClick()
    {
        let newCategoryId = await restClient.createCategory(this.state.choosen.name);
        this.setState({
            choosen: {
                id: newCategoryId,
                name: this.state.choosen.name,
                isNew: false
            },
            searchResult: []
        })
    }
    
    update()
    {
        $(this.domElement.find(".category-list")).remove()
        this.domElement.unbind()
        this.domElement.on("input",(e)=>this.onInput(e))
        $(this.domElement.find(".category-input")[0]).val(this.state.choosen.name)
        $(this.domElement.find("input[name=OperationCategoryId]")[0]).val(this.state.choosen.id)
        let categoriesList = $("<div></div>").addClass("category-list");
        if(this.state.searchResult.length > 0)
        {
            let categoriesElements = this.state.searchResult.map(x =>
                $("<div></div>")
                    .addClass("category-list-element")
                    .text(x.name)
                    .click(()=>{
                        this.setState({ choosen: { id: x.id, name: x.name, isNew: false }, searchResult: []})
                    })

            )
            categoriesList.append(categoriesElements);
        }
        this.domElement.append(categoriesList)
        
        $(this.domElement.find(".add-category")).remove()
        if(this.state.choosen.isNew)
        {
            let categoryButton = $("<div></div>")
                .addClass("add-category")
                .text("+")
                .on("click", ()=>{
                    this.addClick()
                });
            this.domElement.append(categoryButton);
        }
    }
}


class OperationTemplatesSelectSearch
{
    state = {
        name: "",
        searchResult: []
    }

    constructor(domElement) {
        this.domElement=$(domElement)
        this.update()
    }

    setState(newState)
    {
        this.state = newState;
        console.log(this.state)
        this.update();
    }

    async onInput(e)
    {
        let operationTemplates = await restClient.getOperationTemplates(e.target.value)
            .catch(()=>{})
        this.setState({
            name: e.target.value,
            searchResult: operationTemplates == null ? [] : operationTemplates
        })
    }

    async addClick(id)
    {
        await restClient.createOperation(id, $(this.domElement.find("input[name=BudgetId]")[0]).val());
        window.location.reload();
    }

    update()
    {
        $(this.domElement.find(".existing-templates-list")).remove()
        this.domElement.unbind()
        this.domElement.on("input",(e)=>this.onInput(e))
        $(this.domElement.find(".existing-templates-input")[0]).val(this.state.name)
        let operationTemplateList = $("<div></div>").addClass("existing-templates-list");
        if(this.state.searchResult.length > 0)
        {
            let categoriesElements = this.state.searchResult.map(x =>
                $("<div></div>")
                    .addClass("existing-templates-list-element")
                    .text(x.name)
                    .click(()=> this.addClick(x.id))

            )
            operationTemplateList.append(categoriesElements);
        }
        this.domElement.append(operationTemplateList)
    }
}


let components = []
let categoryComponents = $(".category-component");
for(let i=0; i<categoryComponents.length; i++)
{
    components.push(new SelectSearch(categoryComponents[i]))
}

let operationTemplateComponents = $(".existing-template-component");
for(let i=0; i<operationTemplateComponents.length; i++)
{
    components.push(new OperationTemplatesSelectSearch(operationTemplateComponents[i]))
}