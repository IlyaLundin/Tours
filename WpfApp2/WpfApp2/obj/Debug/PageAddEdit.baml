   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.PageAddEdit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  PageAddEdit��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��270 �6   6-   �� 5      6!   .+�5   
   �� $��Название��6      TextBlockMain#��[  6$   6M   �� 5   
   $%��Количество звезд��6   $��1��6,   #��[  69   6b   �� 5   
   $��Страна��6   $��2��6"   #��[  6/   6X   �� 5   
   $��0��6    �� 	MaxLength$	 100��65   $��1��6E     TextBoxMain#��[ 6U   ��6   �� *Name+6|   �� 5   
   -   5        $��1��5      $��1��6>   #��[ 6N   $	��175��6s   $
��Left=�6   ��6   �� *CountOfStars+6�   �� 5   
   -   5         ��Name$ ComboCountries��5   x   $��2��65   $��1��6B     ComboBoxMain#��[ 6R    �� DisplayMemberPath$
 Name��6�    �� SelectedItem 6   �� *	Country+6�   �� 5   
   -   5        $��BtnSave��5   j   $��Сохранить��6   $��2��6%   $��3��69     
ButtonMain#��[ 6F   6�   5      5       