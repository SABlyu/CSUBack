namespace WebApplication1
{
    public class CRUD
    {
    }
}


/*
 * CRUD => Create Read Update Delete
 * 
 * 
 * HTTP request => CRUD
 * 
 * GET == Read
 * 
 * POST == CREATE
 * 
 * PUT == UPDATE
 * 
 * DELETE == DELETE
 * 
 * */


public class AService { }

public class BService { }

public class CService { 
    CService(AService aService) { }
}

public class DService
{
    DService(AService aService, BService bService) { }
}



    /*
     * Controller <--> Service <--> Database 
     */