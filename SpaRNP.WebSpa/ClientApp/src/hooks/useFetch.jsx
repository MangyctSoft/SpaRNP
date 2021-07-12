import { useState, useEffect, useCallback } from "react";

export default (url) => {
  const baseUrl = "http://localhost:5050/api/v1/analysis/";
  const [isLoading, setIsLoading] = useState(false);
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [options, setOptions] = useState({});

  const doFetch = useCallback((options = {}) => {
    setOptions(options);
    setIsLoading(true);
  },[]);

  useEffect(() => {
    if (!isLoading) {
      return;
    }
    
    fetch(baseUrl + url, options)
        .then((response) => {
          return response.json();
        })
      .then(result => {
        setResponse(result)
        setIsLoading(false)
      })
      .catch((error) => {
        setError(error); 
        setIsLoading(false)       
      });
  }, [isLoading, options, url]);

  return [{ isLoading, response, error }, doFetch];
};
