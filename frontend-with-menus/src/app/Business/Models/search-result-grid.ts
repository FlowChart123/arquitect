export interface SearchResultGrid {
    page: number;
    pageSize: number;
    searchTerm: string;
    sortColumn: string;
    sortDirection: string;
    items: any[];
    total: number;
  }