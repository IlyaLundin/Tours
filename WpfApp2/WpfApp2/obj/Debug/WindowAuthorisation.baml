   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   !    WpfApp2.WindowAuthorisation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$I  CТур агентсво Лундина - вход в систему��5   	   $	��400��67   $	��320��6D    � 
ResizeMode$ NoResize=�6P    � Topmost .  � WindowStartupLocation$ CenterScreen=�6u   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   �� ���#bae3e8$��50��6)   $	��320��65      TextBlockMain#��[  6A    �� TextAlignment$ Center=�6h   $#��   Вход в систему��6   �� 5   
   $!��Resource/логотип.png��6   $��40��6.   $
��Left=�6:   $	��Top=�6U   $��5q�6m   �� 5   
     TextBlockAutho#��[ 6   $	��Top=�6<   $��
Логин��6T   $��1��6a   �� 5   
   -   5        $��TbxLogin��5   E     TextBoxAutho#��[ 6   $��1��68   6U   �� 5   
   -   5        $��TblPassword��5   o   #��[ 6   $	��Top=�6<   $��Пароль��6T   $��2��6b   $y�Hidden=�6�   �� 5   
   -   5        $��TbxPassword��5   E   #��[ 6   $��2��68   $y�Hidden=�6X   6l   G� 5   
   -   5        $��PasswordBox��5   L     PasswordBoxMain#��[ 6   $��2��6?   $y�Hidden=�6�   �� 5   
   -   5        $��OpenPassword��5   z   $��2��6   $��Bottom=�6    $��Right=�6;   $��10q�6W   $��25��6c   $��25��6o   $y�Hidden=�6�    � ToolTip$# Показать пароль��6�    d� 	IsChecked$ FalseY�6�   �� 5   
   -   5        $��BtnLogIn��5   B     
ButtonMain#��[ 6   $��3��65   $��
Войти��6R   $y�Hidden=�6y   �� 5   
   $��4��6   ���#445c936!   5      5      