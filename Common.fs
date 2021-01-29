module Common
        type Details =
                {
                        Name : string
                        Description : string
                }

        let describe d =
                printf "\n%s\n\n%s\n" d.Name d.Description 
                

